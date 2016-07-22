using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Threading;


namespace ProductX.framework
{
    public static class GoogleConfigurator
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "TestSpreadsheet";
        private const String AuthPath = "../../resources/";
        public static void GetData()
        {
            var service = ConnectToAPI();
            // Define request parameters.
            String spreadsheetId = "1he8c55LyVXLmYhXedwkM3qGco_1vb9KQkQvz1n1ERio";
            String range = "Content Data!A2:D5";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            foreach (var obj in values)
            {
                Store.Name.Add(obj[0].ToString());
                Store.Sphere.Add(obj[1].ToString());
                Store.Category.Add(obj[2].ToString());
                Store.Audience.Add(obj[3].ToString());
            }
        }

        public static void StoreData(String range)
        {
            var service = ConnectToAPI();
            String spreadsheetId = "1he8c55LyVXLmYhXedwkM3qGco_1vb9KQkQvz1n1ERio";
            //String range = "Results!A2:D2";
            IList<Object> val1 = new List<Object>();
            val1.Add(Store.CASphere);
            IList<Object> val2 = new List<Object>();
            val2.Add(Store.JuniperSphere);
            IList<Object> val3 = new List<Object>();
            val3.Add(Store.JuniperPlatinum);
            IList<Object> val4 = new List<Object>();
            val4.Add(Store.CAPlatinum);
            ValueRange val = new ValueRange();
            val.MajorDimension = "COLUMNS";
            IList<IList<Object>> values = new List<IList<object>>();
            values.Add(val1);
            values.Add(val2);
            values.Add(val3);
            values.Add(val4);
            val.Values = values;
            SpreadsheetsResource.ValuesResource.UpdateRequest request = service.Spreadsheets.Values.Update(val,
                spreadsheetId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW; 
            request.Execute();
        }

        private static SheetsService ConnectToAPI()
        {
            UserCredential credential;
            using (var stream =
                new FileStream(Path.GetFullPath(AuthPath + "google_auth.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = Path.GetFullPath(AuthPath + "google_auth_reworked.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }
    }
}
