using AutoMapper;
using System;
using System.Linq.Expressions;
using XCore.Entities.DataTransferObjects.Categories;
using XCore.Entities.DataTransferObjects.Customers;
using XCore.Entities.DataTransferObjects.Medias;
using XCore.Entities.DataTransferObjects.Rentals;
using XCore.Entities.Models.Overtime;
using XCore.Entities.Models.Rentals;
using XCore.Entities.DataTransferObjects.Crews;
using XCore.Entities.DataTransferObjects.Backups;
using XCore.Entities.DataTransferObjects.JobTitles;
using XCore.Entities.DataTransferObjects.RuleTypes;
using XCore.Entities.DataTransferObjects.Employees;

namespace XCore.Api.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Customer, CustomerDto>().ReverseMap();
            this.CreateMap<CustomerForCreationDto, Customer>();
            this.CreateMap<CustomerForUpdateDto, Customer>();
            this.CreateMap<Category, CategoryDto>().ReverseMap();
            this.CreateMap<CategoryForCreationDto, Category>();
            this.CreateMap<CategoryForUpdateDto, Category>();
            this.CreateMap<Media, MediaDto>().ForMember<string>((Expression<Func<MediaDto, string>>)(x => x.Category), (Action<IMemberConfigurationExpression<Media, MediaDto, string>>)(options => options.MapFrom<string>((Expression<Func<Media, string>>)(e => e.ItemCategory.Description))));
            this.CreateMap<MediaForCreationDto, Media>();
            this.CreateMap<MediaForUpdateDto, Media>();
            this.CreateMap<Rental, RentalDto>().ForMember<string>((Expression<Func<RentalDto, string>>)(x => x.Customer), (Action<IMemberConfigurationExpression<Rental, RentalDto, string>>)(options => options.MapFrom<string>((Expression<Func<Rental, string>>)(e => e.Customer.FirstName + (object)' ' + e.Customer.LastName)))).ForMember<string>((Expression<Func<RentalDto, string>>)(x => x.Media), (Action<IMemberConfigurationExpression<Rental, RentalDto, string>>)(options => options.MapFrom<string>((Expression<Func<Rental, string>>)(e => e.Media.ItemTitle)))).ForMember<string>((Expression<Func<RentalDto, string>>)(x => x.Category), (Action<IMemberConfigurationExpression<Rental, RentalDto, string>>)(options => options.MapFrom<string>((Expression<Func<Rental, string>>)(e => e.Media.ItemCategory.Description))));
            this.CreateMap<RentalForCreationDto, Rental>();
            this.CreateMap<RentalForUpdateDto, Rental>();

            // Backups Mapping
            CreateMap<BackupDto, Backup>().ReverseMap();
            CreateMap<BackupCreationDto, Backup>();

            // Crews Mapping
            CreateMap<CrewDto, Crew>().ReverseMap();
            CreateMap<CrewCreationDto, Crew>();

            // JobTitles Mapping
            CreateMap<JobTitleDto, JobTitle>().ReverseMap();
            CreateMap<JobTitleCreationDto, JobTitle>();

            // RuleTypes Mapping
            CreateMap<RuleTypeDto, RuleType>().ReverseMap();
            CreateMap<RuleTypeCreationDto, RuleType>();

            // Employees Mapping
            CreateMap<Employee, EmployeeDto>()
                .ForMember(x => x.Crew, options => options.MapFrom(e => e.Crew.Name))
                .ForMember(x => x.JobTitle, options => options.MapFrom(e => e.JobTitle.Name))
                .ForMember(x => x.RuleType, options => options.MapFrom(e => e.RuleType.Name))
                .ForMember(eb => eb.EmployeeBackups, options => options.MapFrom(eb => eb.EmployeeBackups));

            CreateMap<EmployeeCreationDto, Employee>();

            CreateMap<EmployeeBackupDto, EmployeeBackup>().ReverseMap();
        }
    }
}
