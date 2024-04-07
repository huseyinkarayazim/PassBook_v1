# PassBook_v1

This application using mongodb cloud service, you have to add your cloud account link in the appconfig file.
   Ex: <appSettings>
  		 <add key="Link"   value="your cloud mongo db address here"   />
  	   </appSettings>
Than you have to change this strings "initVector","passPhrase" in "security.cs". This is working for Encrypt / Dencrypt your data.

I will add 2FA for the login method.
