﻿using Data.Repositories;
using System;

namespace YouBay.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        /* ---------------------------------------------------------------------- */
        ICategoryRepository CategoryRepository { get; }
        ISubcategoryRepository SubcategoryRepository { get; }
        IAssistantItemsRepository AssistantItemsRepository { get; }

        IAuctionRepository AuctionRepository { get; }

        IBuyerRepository BuyerRepository { get; }

        ICustomizedAdsRepository CustomizedAdsRepository { get; }

        IHistoryOfViewsRepository HistoryOfViewsRepository { get; }

        IManagerRepository ManagerRepository { get; }

        IOrderAndReviewRepository OrderAndReviewRepository { get; }

        IProductHistoryRepository ProductHistoryRepository { get; }

        IProductRepository ProductRepository { get; }

        ISellerRepository SellerRepository { get; }

        ISpecialPromotionRepository SpecialPromotionRepository { get; }

        //ISubcategoryRepository SubcategoryRepository { get; }


        IYouBayUserRepository YouBayUserRepository { get; }
        /* ---------------------------------------------------------------------- */

    }
}
