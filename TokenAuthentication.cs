//Install-Package System.IdentityModel.Tokens.Jwt

//Install-Package BCrypt.Net

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace UserInterface.TokenAuth{

public   class TokenAuthentication{


// Create a method to generate a JWT token
public  static string GenerateJwtToken(string username)
{

     string secretKey = "ACDt1vR3lXToPQ143g3MyN1242HDGGS$%^&$te^%3w&%h*j()hqjq=="; //Generate random String from https://www.random.org/strings
     string issuer = "http://localhost:28747"; //Project Property-> Debug-> IIS-->App URL (you can local host url as well)
     string audience = "http://localhost:28747";

    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    var claims = new[]
    {
        new Claim(ClaimTypes.Name, username),
        // Add other claims as needed
    };

    var token = new JwtSecurityToken(
        issuer: issuer,
        audience: audience,
        claims: claims,
        expires: DateTime.UtcNow.AddHours(1), // Set the token expiration time
        signingCredentials: credentials
    );

    var tokenHandler = new JwtSecurityTokenHandler();
    return tokenHandler.WriteToken(token);
}

}

}

/*string secretKey = "your_secret_key";
string issuer = "your_issuer";
string audience = "your_audience";
string username = "user123";

string token = GenerateJwtToken(secretKey, issuer, audience, username);*/








/*
using BCrypt.Net;

// Hash and save the password
public string HashPassword(string password)
{
    // Generate a salt
    string salt = BCrypt.Net.BCrypt.GenerateSalt(12); // You can adjust the salt work factor (cost) as needed

    // Hash the password using the salt
    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

    // Store the hashedPassword in your database
    return hashedPassword;
}


string password = "user123password";
string hashedPassword = HashPassword(password);
// Store `hashedPassword` in your database along with the salt


public bool VerifyPassword(string password, string storedHash)
{
    return BCrypt.Net.BCrypt.Verify(password, storedHash);
}


string storedHash = "hash_retrieved_from_database"; // Retrieve this from your database
bool passwordMatch = VerifyPassword(enteredPassword, storedHash);

if (passwordMatch)
{
    // Password is correct; allow user to log in
}
else
{
    // Password is incorrect; deny access
}*/
