﻿using Business.Abstract;
using Entities.Concrete;
using MernisServiceReference;
namespace Business.Concrete;
public class PersonManager : IApplicantService
{
    //encapsulation
    public void ApplyForMask(Person person)
    {
    }
    public List<Person> GetList()
    {
        return null;
    }
    public bool CheckPerson(Person person)
    {
        KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);
        var result = client.TCKimlikNoDogrulaAsync(
            new TCKimlikNoDogrulaRequest
            (new TCKimlikNoDogrulaRequestBody(person.NationalIdentity, person.FirstName, person.LastName, person.DateOfBirthYear)));
        return result.Result.Body.TCKimlikNoDogrulaResult;
    }
}