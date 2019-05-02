using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    private static readonly String chars = "abcdefghijeklmnopqrestuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private static readonly Random random = new Random();
	public Common()
	{
		//
		// TODO: Add constructor logic here
		//


	}

    public static string AlphanumericString()
    {
        return new string(
            Enumerable.Repeat(chars, 8)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
    }

}