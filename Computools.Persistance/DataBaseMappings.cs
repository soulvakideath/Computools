using AutoMapper;
using Computools.Core.Models;
using Computools.Persistance.Entities;

namespace Computools.Persistance;

public class DataBaseMappings : Profile
{
    public DataBaseMappings()
    {
        CreateMap<SubjectEntity, Subject>();
        CreateMap<StudentEntity, StudentEntity>();
    }
}