﻿using Store.Contracts;
using Store.Contracts._Base;
using Store.DomainModels._Exceptions;
using System;
using System.Threading.Tasks;

namespace Store.Infrastructure.DataAccess._Base
{
    public sealed class UnitOfWork<TDbContext> : IUnitOfWork
        where TDbContext : BaseDbContext
    {
        public IProductRepository Product { get; }

        private readonly TDbContext _dbContext;
        private readonly IUnitOfWorkConfiguration _config;
        public UnitOfWork(TDbContext dbContext,
            IUnitOfWorkConfiguration config,
            IProductRepository product)
        {
            _dbContext = dbContext;
            _config = config;

            Product = product;
        }

        public void InitiateDatabase()
        {
            if (!_config.Seed.IsEnable)
                return;

            try
            {
                //
                Commit();
            }
            catch (Exception ex)
            {
                throw new InitializeDataBaseException(ex);
            }
        }
        public async Task InitiateDatabaseAsync()
        {
            if (!_config.Seed.IsEnable)
                return;

            try
            {
                //
                await CommitAsync();
            }
            catch (Exception ex)
            {
                throw new InitializeDataBaseException(ex);
            }
        }

        public void BeginTransaction() => _dbContext.BeginTransaction();
        public Task BeginTransactionAsync() => _dbContext.BeginTransactionAsync();

        public int Commit() => _dbContext.SaveChanges();
        public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();

        public void Rollback() => _dbContext.RollbackTransaction();
        public Task RollbackAsync() => _dbContext.RollbackTransactionAsync();
    }
}