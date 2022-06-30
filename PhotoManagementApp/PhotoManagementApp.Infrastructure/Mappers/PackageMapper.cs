using PhotoManagementApp.Application.Package.CreatePackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManagementApp.Infrastructure.Mappers
{
    internal static class PackageMapper
    {
        public static CreatePackageDto MapToCreatePackageDto(this Entities.Package model)
        {
            if (model == null)
                return null;

            return new CreatePackageDto
            {
                Id = model.Id
            };
        }

        public static Entities.Package MapToDb(this Domain.Package.Package model)
        {
            if (model == null)
                return null;

            return new Entities.Package
            {
                Id = model.Id, 
                Active = model.Active, 
                Code = model.Code, 
                DateCreated = model.DateCreated,
                DateLastModified = model.DateLastModified, 
                Name = model.Name, 
                PackageRestrictionValues = model.RestrictionValues.Select(x => x.MapToDb()).ToList(),
                UserCreatedId = model.UserCreatedId, 
                UserLastModifiedId = model.UserLastModifiedId
            };
        }

        public static Entities.PackageRestrictionValue MapToDb(this PhotoManagementApp.Domain.Package.ValueObjects.PackageRestrictionValue model)
        {
            return new Entities.PackageRestrictionValue
            {
                Id = model.Id,
                Active = model.Active,
                DateCreated = model.DateCreated,
                DateLastModified = model.DateLastModified,
                PackageId = model.PackageId,
                PackageRestrictionId = model.PackageRestrictionId,
                Value = model.Value,
                UserCreatedId = model.UserCreatedId,
                UserLastModifiedId = model.UserLastModifiedId
            };
        }
    }
}
