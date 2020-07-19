using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlighMaster.WinUI.Api;
using Flurl.Http;

namespace FlighMaster.WinUI
{
    public class ApiBuilder
    {
        public string URL=null;
        string Token = Properties.Settings.Default.Token;

        public ApiBuilder(string uRL)
        {
            URL = uRL;
        }

        public async Task<T> Get<T>()
        {

  
            try
            {
                var result = await $"{Properties.Settings.Default.ApiUrl}/{URL}".WithOAuthBearerToken(Token).GetJsonAsync<T>();

                return result;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    
                    MessageBox.Show("Niste authentificirani");
                }
                throw;
            }



        }



        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.ApiUrl}/{URL}";

            try
            {
                return await url.WithOAuthBearerToken(Token).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }

        public async Task<T> Remove<T>(int id)
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiUrl}/{URL}/{id}";

                return await url.WithOAuthBearerToken(Token).DeleteAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }

        public async Task<T> Update<T>(int id, object request)
        {
            try
            {
                var url = $"{Properties.Settings.Default.ApiUrl}/{URL}/{id}";

                return await url.WithOAuthBearerToken(Token).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }
     
    }
}
