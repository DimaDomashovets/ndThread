using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;

namespace RestClientD
{
    public class Class1
    {
        public RestClient client;
        public RestRequest request;

        public Class1(string baseUrl)
        {
            client = new RestClient(baseUrl) { UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.120 Safari/537.36" };
            //client.AddDefaultHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJ1c2VyX2lkIjoiNDMwIiwiZW1haWwiOiJkaW1hZG9tYXNob3ZldHNAZ21haWwuY29tIiwiZXhwIjoxNTc2ODI" +
            //    "3ODc4LCJyZWZyZXNoX3Rva2VuIjoiNlRVK0JMODBaK09xSUFyRnVCWGtzODNnSU1XSTZlSzNwc0IzazM1ZU9NdEZEY0lZK0czVmp4N1hoRjkyVFp3ZVg5SDRDNmZhL2h0OTRQeGF2STdjMEE9PS" +
            //    "IsInRva2VuIjoiRk8wOU9mSkV4NW1FdkdNcGN0eFJtYXlYYXAyQzUwbzBRdGtZRDVWZTN0V1Fnam42UXNRT09VWnhOMWZWbWVZVnh3SzNzMGJmTmUzY3VtQzRnSERPZGxLdEI3V1JSUldoUElvTmd" +
            //    "kR0dzSFZjRFNpN21Vbm8wMFdGcTMxdkFXTjdiNTQwRDFlUDlCeHcvN1I1cFlmY09pQlRxWXRHQUhjVTgzdUZ3bzAram5kYlhtRzBleHFpdDcwTGFrZE9XckVGV2pkR1NoQjh1SnFwNDlEdEZ0UitxZ" +
            //    "1dUVE51UWMzbGZCQmwvOEsxdDdsQT0ifQ.2M1VZXG4Hp50Mmd9ChFcD4StfdfvhExHnJprfsRz2v4");
            client.AddDefaultHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJ1c2VyX2lkIjoiNDMzIiwiZW1haWwiOiJkaW1hZG9tYXNob3ZldHMrZXh0ZXJuYWwuMDFAZ21haWwuY29tIiwiZXh" +
                "wIjoxNTc2OTI5NzcyLCJyZWZyZXNoX3Rva2VuIjoiQWo3UkFlclVId3VOUktkS09WZnlHZEpZMTAzMmVZcGJVa043dnJ5bmtOTWFISXc3WHo1TElzYlVnckh4cndlYWF1TTVaanBST2dDRzdYZC85" +
                "RTlCMHc9PSIsInRva2VuIjoiclVNNm1KNC8welZHZXd1cktjaGEzNklvd2FJUmtqeHhkcUxmNTJ6OSt2bmI5VUM1ZXl4MnppN240S0R5d1JYYVRpcmIvR21BdkQrZklndE9aenl2SVc5VEVhVEczK" +
                "3o0anZWR2NiZjNVOHdQUks1YlExZ3FGR0hUam9CZU8zYjV5bjRSd1dLUnB1a1dzVTlpY09VcjNrbkhsb2U4djFzR29PQmdHTFVoSGM3Q3dRelgzR1EvcXJkNGJQeExsczNnclV6ME85eHlwckpwK" +
                "1VoNVBPSjVmZXdPVGlHZFpWMjJHZHJVck5NamRmaz0ifQ.ky30uldyb_nlGUELOPumWbHiBk4OlEK_wzXmNZPlgyE");
        }

        public void CreateStich(string id)
        {
            request = new RestRequest($"/api/v2/threads/{id}/stitches?embed=author", Method.POST);
            //
            JsonBody jsonBody = new JsonBody() { body = "Good bye" };
            request.AddJsonBody(jsonBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            Console.WriteLine(content);

        }
        public void CreateThreadByInternUser(string id)
        {
            request = new RestRequest($"/api/v2/ws/{id}/threads?embed=members",Method.POST);
            JsonBody jsonBody = new JsonBody() { name = "GGGGGGGGGGGGGG", security = false, ws_id = id };
            request.AddJsonBody(jsonBody);
            IRestResponse response = client.Execute(request);

        }

        public JsonNet CreateThreadByExternUser(string id)
        {
            request = new RestRequest($"/api/v2/ws/{id}/threads?embed=members",Method.POST);
            JsonBody jsonBody = new JsonBody() { name = "ExternalThreadichdd", security = false, ws_id = id };
            request.AddJsonBody(jsonBody);
            IRestResponse response = client.Execute(request);
            JsonNet json = new JsonDeserializer().Deserialize<JsonNet>(response);
            return json;
        }


        public JsonNet CreateThreadByAdm()
        {
            request = new RestRequest("/api/v2/ws/353/threads?embed=members", Method.POST);
            JsonBody jsonBody = new JsonBody() { name = "ApiThread12324", security = false, ws_id = "353" };
            request.AddJsonBody(jsonBody);
            IRestResponse response = client.Execute(request);
            string content = response.Content;
            Console.WriteLine(content);
            JsonNet json = new JsonDeserializer().Deserialize<JsonNet>(response);
            Console.WriteLine("----------------");
            //
            return json;
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonNet
    {
        [JsonProperty("conversations")]
        public string conversations { get; set; }

        [JsonProperty("created_at")]
        public string created_at { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("error")]
        public string error { get; set; }

    }

    class JsonBody
    {
        public string body { get; set; }
        public string name { get; set; }
        public bool security { get; set; }
        public string users { get; set; }
        public string ws_id { get; set; }

    }

}
