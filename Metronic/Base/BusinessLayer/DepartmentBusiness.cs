using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using AutoMapper;
using Ponera.Base.BusinessLayer.Contracts;
using Ponera.Base.BusinessLayer.Proxy;
using Ponera.Base.DataAccess;
using Ponera.Base.DataAccess.Contracts;
using Ponera.Base.Entities;
using Ponera.Base.Models;

namespace Ponera.Base.BusinessLayer
{
    public class DepartmentBusiness : IDepartmentBusiness
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentBusiness()
        {
            _departmentRepository = PoneraProxyGenerator.GenerateRepositoryProxy<IDepartmentRepository, DepartmentRepository>();

            Mapper.CreateMap<Department, DepartmentModel>();
            Mapper.CreateMap<DepartmentModel, Department>();
        }

        public IList<DepartmentModel> GetDepartments(bool? deleted = false)
        {
            IList<Department> allDepartments = _departmentRepository.GetAllDepartments(deleted);

            List<DepartmentModel> departmentModels = allDepartments.Select(department => Mapper.Map<Department, DepartmentModel>(department)).ToList();

            return departmentModels;
        }

        public void AddDepartment(DepartmentModel departmentModel)
        {
            if (departmentModel == null)
            {
                throw new ArgumentNullException(nameof(departmentModel));
            }

            Contract.Requires(!string.IsNullOrEmpty(departmentModel.Name));

            Department department = Mapper.Map<DepartmentModel, Department>(departmentModel);

            department.CreateDate = DateTime.Now;
            department.CreateUserId = 0; // TODO : Bu alana hangi user işlem yaptıysa eklenecek.
            
            _departmentRepository.Add(department);

            departmentModel.Id = department.Id;
        }

        public void UpdateDepartment(DepartmentModel departmentModel)
        {
            if (departmentModel == null)
            {
                throw new ArgumentNullException(nameof(departmentModel));
            }

            Contract.Requires(!string.IsNullOrEmpty(departmentModel.Name));
            Contract.Requires(departmentModel.Id > 0);

            Department department = Mapper.Map<DepartmentModel, Department>(departmentModel);
            department.UpdateDate = DateTime.Now;
            department.UpdateUserId = 0;

            _departmentRepository.Update(department);
        }

        public void DeleteDepartment(int departmentId)
        {
            Department department = _departmentRepository.GetById(departmentId);

            department.Deleted = true;
            department.UpdateDate = DateTime.Now;
            department.UpdateUserId = 0;

            _departmentRepository.Update(department);
        }
    }
}
