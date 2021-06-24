﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using System.Data.Entity;
using BookstoreBackend.Models.Order;
using BookstoreBackend.Repository.OrdersInterface;
using BookstoreBackend.ViewModel.ManageOrders;
using BookstoreBackend.Repository.SearchImplementations;

namespace BookstoreBackend.Repository.Implementations.OrderImplementations
{

    public class OrderRepository : IOrderRepository
    {
        /*
         * Order Repository contains all functions associated with Order Model
         */

        private readonly int _ordersPerPage = 20;
        private readonly string[] OrderIncludes = { "Customer", "Address", "OrderStatus" };
        private ISearchRepository _searchRepo;
        private IOrderDatabaseCalls _orderDbCalls;
        private IExpressionFunction _expFunc;

        // Set up connection to Database 
        public OrderRepository(ISearchRepository searchRepo, IOrderDatabaseCalls orderDbCalls, IExpressionFunction expFunc)
        {
            _searchRepo = searchRepo;
            _orderDbCalls = orderDbCalls;
            _expFunc = expFunc;
        }



        // Find Single Order by the Order Id
        public async Task<Order> FindOrderById(long id)
        {
            string filterValue = "Order_Id";
            string searchString = "" + id;
            string inBetween = "";
            string operand = "==";
            string negate = "false";

            Order order = null;
            try
            {
                var query = FilterOrder(filterValue, searchString, inBetween, operand, negate);

                order = query.First();
            }
            catch(InvalidOperationException ex)
            {
                order = null;
            }

            

            return order;
        }

        private ManageOrderViewModel RetrieveViewModel(string filterValue, string searchString, int pageNum, int totalPages, int[] pages, List<Order> order)
        {
            ManageOrderViewModel viewModel = new ManageOrderViewModel();

            viewModel.SearchString = searchString;
            viewModel.FilterValue = filterValue;
            viewModel.Orders = order;
            viewModel.Pages = pages;
            viewModel.HasPreviousPages = (pageNum > 1);
            viewModel.CurrentPage = pageNum;
            viewModel.HasNextPages = (pageNum < totalPages);

            return viewModel;
        }


        // Find All the Orders in the Table
        public async Task<ManageOrderViewModel> GetAllOrders(int pageNum)
        {

            ManageOrderViewModel viewModel = new ManageOrderViewModel();

            var orderBase = _orderDbCalls.GetBaseQuery("BookstoreBackend.Models.Order.Order");

            var query = _orderDbCalls.ReturnBaseQuery<Order>(orderBase, OrderIncludes);

            var totalPages = _searchRepo.GetTotalPages(query.Count(),_ordersPerPage);

            viewModel = await RetrieveFilterViewModel(query, totalPages, pageNum, "", "");

            return viewModel;
        }


        private async Task<ManageOrderViewModel> RetrieveFilterViewModel(IQueryable<Order> filterQuery, int totalPages, int pageNum, string filterValue, string searchString) 
        {
            ManageOrderViewModel viewModel = new ManageOrderViewModel();

            var orders = filterQuery
                            .OrderBy(order => order.OrderStatus.position)
                            .ThenBy(order => order.DeliveryDate)
                            .Skip((pageNum - 1) * _ordersPerPage)
                            .Take(_ordersPerPage)
                            .ToList();

            int[] pages = _searchRepo.GetModifiedPagesArr(pageNum, totalPages);

            viewModel = RetrieveViewModel(filterValue, searchString, pageNum, totalPages, pages, orders);

            return viewModel;
        }


   
        public async Task<ManageOrderViewModel> FilterList(string filterValue, string searchString, int pageNum)
        {

            ManageOrderViewModel viewModel = new ManageOrderViewModel();
            var parameterExpression = _expFunc.ReturnParameterExpression(typeof(Order), "Order");

            var expression = _searchRepo.ReturnExpression(parameterExpression, filterValue, searchString);

            Expression<Func<Order, bool>> lambda = _expFunc.ReturnLambdaExpression<Order>(expression, parameterExpression);
         
            if (lambda == null)
            {
                int[] pages = Enumerable.Range(1, 1).ToArray();


                viewModel = RetrieveViewModel("", "", 1, 1, pages, null);
                return viewModel;
            }
            var orderBase = _orderDbCalls.GetBaseQuery("BookstoreBackend.Models.Order.Order");

            var query = _orderDbCalls.ReturnBaseQuery<Order>(orderBase, OrderIncludes);

            var filterQuery = _orderDbCalls.ReturnFilterQuery<Order>(query, lambda);

            int totalPages = _searchRepo.GetTotalPages(filterQuery.Count(), _ordersPerPage);

            viewModel = await RetrieveFilterViewModel(filterQuery, totalPages, pageNum, filterValue, searchString);
            return viewModel;

        }


        public IQueryable<Order> FilterOrder(string filterValue, string searchString, string inBetween, string operand, string negate)
        {
            //string filterValueTest = "Order_Id Customer.Customer_Id";
            //string tableNameTest = "Order";
            //var parameterExpressionTest = Expression.Parameter(typeof(Order), "order");
            //var searchStringTest = "47&&2";
            //var inBetweenTest = "And Or";
            //var operandTest = "== ==";
            //var negateTest = "false true";

            string tableName = "Order";

            Expression<Func<Order, bool>> lambda = _expFunc.ReturnLambdaExpression<Order>(tableName, filterValue, searchString, inBetween, operand, negate);

            var orderBase = _orderDbCalls.GetBaseQuery("BookstoreBackend.Models.Order.Order");

            var query = _orderDbCalls.ReturnBaseQuery<Order>(orderBase, OrderIncludes);

            var filterQuery = _orderDbCalls.ReturnFilterQuery(query, lambda);

            return filterQuery;
        }

    }
}
