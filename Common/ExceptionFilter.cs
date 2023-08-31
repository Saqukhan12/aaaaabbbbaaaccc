namespace DotNetCoreBoilerplate.Common
{
    //public class ExceptionFilter : IExceptionFilter
    //{

    //    public IConfiguration Configuration { get; }
    //    static SqlConnection con;
    //    public ExceptionFilter(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    private void DbCon()
    //    {

    //        string constr = Configuration.GetConnectionString("DefaultConnection");
    //        con = new SqlConnection(constr);

    //    }

    //    public void OnException(ExceptionContext context)
    //    {
    //        try
    //        {
    //            DbCon();
    //            using (SqlCommand cmd = new SqlCommand())
    //            {

    //                cmd.Connection = con;
    //                cmd.CommandType = CommandType.Text;
    //                cmd.CommandText = @"INSERT INTO ExceptionHandler(ExceptionId,URL,ExceptionString,Datetime) VALUES(@ExceptionId,@AdressURL,@ExceptionString,@Datetime)";
    //                cmd.Parameters.AddWithValue("@ExceptionId", Guid.NewGuid());
    //                cmd.Parameters.AddWithValue("@AdressURL", context.HttpContext.Request.GetDisplayUrl());
    //                cmd.Parameters.AddWithValue("@ExceptionString", context.Exception.InnerException.ToString());
    //                cmd.Parameters.AddWithValue("@Datetime", DateTime.Now);

    //                con.Open();
    //                cmd.ExecuteNonQuery();


    //            }
    //            context.ExceptionHandled = true;
    //            context.Result = new RedirectResult(context.HttpContext.Request.Path.ToString(), true);

    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);

    //        }

    //    }

    //}

}