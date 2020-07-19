﻿using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FlightMaster.MobileApp.Services
{
    class ApiCaller
    {

        string URL = "http://localhost:19228/api/";
        string Token = "";

        public ApiCaller()
        {
            Token = (string) Application.Current.Properties["TOKEN"];
        }
        public ApiCaller(string Token)
        {
            this.Token = Token;
        }

        public async Task<T> LogInRegister<T>(object LogInData, string ControllerName, string RouteName = "")
        {

            string url = URL;

            try
            {

                url += ControllerName;
                if (RouteName != "")
                    url += "/" + RouteName;



                return await url.PostJsonAsync(LogInData).ReceiveJson<T>();

            }
            catch (FlurlHttpException ex)
            {


                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);
                    //  throw;

                }



                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }


        }

        public async Task<T> GetAll<T>(string ControllerName, string RouteName = "")
        {

            string url = URL;

            try
            {

                url += ControllerName;
                if (RouteName != "")
                    url += "/" + RouteName;

                return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {

                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);
                }

                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }


        }


        public async Task<T> GetByObject<T>(string ControllerName, object obj, string RouteName = "")
        {

            string url = URL;

            try
            {

                url += ControllerName;
                if (RouteName != "")
                    url += "/" + RouteName;


               return await url.WithOAuthBearerToken(Token).PostJsonAsync(obj).ReceiveJson<T>();


            }
            catch (FlurlHttpException ex)
            {

                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }


        }



        public async Task<T> GetAllByID<T>(string ControllerName, int id, string RouteName = "")
        {

            string url = URL;

            try
            {

                url += ControllerName;
                if (RouteName != "")
                    url += "/" + RouteName;
                url += "?id=" + id;

                return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }


        }

        public async Task<T> SearchAll<T>(string ControllerName, string Search, string RouteName = "")
        {
            string url = URL;

            try
            {

                url += ControllerName;
                if (RouteName != "")
                    url += "/" + RouteName;

                if (Search != "")
                {
                    url += "?search=" + Search;
                }


                return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }
        }


        public async Task<T> SearchPagenation<T>(string ControllerName, int page, string search, string RouteName = "")
        {
            string url = URL;

            try
            {

                url += ControllerName;
                if (RouteName != "")
                    url += "/" + RouteName;

                url += "?" + "page=" + page;
                url += "&" + "search=" + search;

                return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }
        }

        public async Task<T> SearchPagenationByID<T>(string ControllerName, int page, string search, int id, string RouteName = "")
        {
            string url = URL;

            try
            {

                url += ControllerName;
                if (RouteName != "")
                    url += "/" + RouteName;
                url += "/" + id;

                url += "?" + "page=" + page;
                url += "&" + "search=" + search;

                return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }
        }


        public async Task<T> GetPageDefault<T>(string ControllerName, int page, string RouteName = "")
        {
            string url = URL;


            try
            {

                url += ControllerName;
                if (RouteName != "")
                    url += "/" + RouteName;

                url += "?" + "page=" + page;

                return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }

        }


        public async Task<T> UpdateOne<T>(string ControllerName, object edited, string RouteName = "")
        {
            string url = URL;

            try
            {

                url += ControllerName;
                if (RouteName != "")
                    url += "/" + RouteName;


                return await url.WithOAuthBearerToken(Token).PutJsonAsync(edited).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }

        }

        public async Task<T> RemoveByObject<T>(string ControllerName, object deleted, string RouteName = "")
        {
            string url = URL;

            try
            {

                url += ControllerName;
                if (RouteName != "")
                    url += "/" + RouteName;


                return await url.WithOAuthBearerToken(Token).SendJsonAsync(System.Net.Http.HttpMethod.Delete, deleted).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }
        }

        public async Task<T> RemoveOneById<T>(string ControllerName, int ID, string RouteName = "")
        {

            string url = URL;
            url += ControllerName;
            if (RouteName != "")
                url += "/" + RouteName;
            url += "/" + ID;

            try
            {

                return await url.WithOAuthBearerToken(Token).DeleteAsync().ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }

        }

        public async Task<T> Insert<T>(object request, string ControllerName, string RouteName = "")
        {

            string url = URL;

            url += ControllerName;
            if (RouteName != "")
                url += "/" + RouteName;

            try
            {
                return await url.WithOAuthBearerToken(Token).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }



        }



        public async Task<T> GetQuery<T>(Dictionary<string,object> request, string ControllerName, string RouteName = "")
        {

            string url = URL;

            url += ControllerName;
            if (RouteName != "")
                url += "/" + RouteName;

            try
            {
                url += "?";
                foreach (var param in request)
                {
                    url += param.Key;
                    url += "=";
                    url += param.Value;
                    url += "&";

                }
                url = url.Remove(url.Length - 1);


                return await url.WithOAuthBearerToken(Token).GetJsonAsync<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }



        }
        public async Task<T> PatchOne<T>(object request, string ControllerName, string RouteName = "")
        {

            string url = URL;

            url += ControllerName;
            if (RouteName != "")
                url += "/" + RouteName;

            try
            {
               
                return await url.WithOAuthBearerToken(Token).PatchJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    return default(T);

                }
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                return default(T);
            }



        }
    }
}
