﻿namespace Newdapper
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            //the API point mapping
            app.MapGet("/Users", GetUsers);
            app.MapGet("/Users/{id}", GetUser);
            app.MapPost("/Users", InsertUser);
            app.MapPut("/Users", UpdateUser);
            app.MapDelete("/Users", DeleteUser); 

        }

        private static async Task<IResult> GetUsers(IUserData data)
        {
            try
            {
                return Results.Ok(await data.GetUsers());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
        private static async Task<IResult> GetUser(int id, IUserData data)
        {
            try
            {
                var results = await data.GetUser(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


        private static async Task<IResult> UpdateUser(UserModels user, IUserData data)
        {
            try
            {
                await data.UpdateUser(user);
                return Results.Ok();

            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message); 
            }
        }


        private static async Task<IResult> InsertUser(UserModels user, IUserData data)
        {
            try
            {
                await data.InsertUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        private static async Task<IResult> DeleteUser(int id, IUserData data)
        {
            try
            {
                await data.DeleteUser(id);
                return Results.Ok();

            }

            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

    }
}
