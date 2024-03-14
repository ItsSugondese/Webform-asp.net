using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EditHelper
/// </summary>
public class EditHelper
{
    public static string getIdIfEdit(HttpRequest Request)
    {
        return Request.QueryString["id"];

    }

    public static bool checkIfExits(HttpRequest request)
    {
        if (!string.IsNullOrEmpty(EditHelper.getIdIfEdit(request)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}