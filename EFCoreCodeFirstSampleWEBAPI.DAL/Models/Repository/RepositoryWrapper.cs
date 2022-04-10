﻿using EFCoreCodeFirstSampleWEBAPI.Models.Repository.Interface;
using EFCoreCodeFirstSampleWEBAPI.Models.Repository.Rep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSampleWEBAPI.Models.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MyAppContext _myAppContext;
        private IUserRepository _user;
        private IFilmsRepository _films;
        private IFilmsUsersRepository _filmsUsers;

        public RepositoryWrapper(MyAppContext myAppContext)
        {
            _myAppContext = myAppContext;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_myAppContext);
                }
                return _user;
            }
        }

        public IFilmsRepository Films
        {
            get
            {
                if (_films == null)
                {
                    _films = new FilmsRepository(_myAppContext);
                }
                return _films;
            }
        }

        public IFilmsUsersRepository FilmsUsers
        {
            get
            {
                if (_filmsUsers == null)
                {
                    _filmsUsers = new FilmsUsersRepository(_myAppContext);
                }
                return _filmsUsers;
            }
        }

        public async void SaveAsync()
        {
            await _myAppContext.SaveChangesAsync();
        }
    }
}