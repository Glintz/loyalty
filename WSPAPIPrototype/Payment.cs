﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace WSPAPIPrototype
{
    public  class Payment : IProcess
    {

        public void Process()
        {
            var result = string.Empty;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://mercuryrestapi.azurewebsites.net/api/payments/Transactions?customerid=12345&timestamp=50394852&hash=3a23fb806103fb33d8518c7f505232674976217a");
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                string json = "{\"TransactionId\":\"0\",\"OperatorId\":\"0\", \"TranType\":\"Credit\", \"TranCode\":\"Sale\", \"InvoiceNo\":\"123\",\"RefNo\":\"0\", \"Account\":\"5499****\",\"Amount\":\"69\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }

            #region JSON Deserialization
            //Put a break point here and checkout the RootObject data. 
            RootObject ro = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(result);
            #endregion
        }
    }

    public class RootObject
    {
        public int TransactionId { get; set; }
        public int OperatorId { get; set; }
        public string TranType { get; set; }
        public string TranCode { get; set; }
        public int InvoiceNo { get; set; }
        public int RefNo { get; set; }
        public object Account { get; set; }
        public int AccountType { get; set; }
        public object Amount { get; set; }
    }
}
