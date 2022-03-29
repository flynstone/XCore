using AutoMapper;
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
using XCore.Entities.DataTransferObjects.Users;
using XCore.Entities.Models;

namespace XCore.Api.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Identity Maps
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            // Rental Project maps
            this.CreateMap<Customer, CustomerDto>().ReverseMap();
            this.CreateMap<CustomerForCreationDto, Customer>();
            this.CreateMap<CustomerForUpdateDto, Customer>();
            this.CreateMap<Category, CategoryDto>().ReverseMap();
            this.CreateMap<CategoryForCreationDto, Category>();
            this.CreateMap<CategoryForUpdateDto, Category>();
            this.CreateMap<Media, MediaDto>().ForMember(x => x.Category, options => options.MapFrom(e => e.ItemCategory.Description));
            this.CreateMap<MediaForCreationDto, Media>();
            this.CreateMap<MediaForUpdateDto, Media>();
            this.CreateMap<Rental, RentalDto>().ForMember(x => x.Customer, options => options.MapFrom(e => e.Customer.FirstName + ' ' + e.Customer.LastName)).ForMember(x => x.Media, options => options.MapFrom(e => e.Media.ItemTitle));
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
