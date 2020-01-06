(function () {
    var app = new Vue({
        el: '#app',
        data: {
            filter: {
                name: window.injectObj.productList.ProductName || '',
                price: window.injectObj.productList.Price || '',
                quantity: window.injectObj.productList.Quantity || '',
                canSale: window.injectObj.productList.CanSale,
                address: ''
            },
            urls: {
                updateProduct: window.injectObj.urls.updateProduct || '',
                detailPath: window.injectObj.urls.detailPath || ''
            },
            productList: window.injectObj.productList,
        },
        methods: {
            /*
            * change table page
            * @param {} val: 頁碼
            */
            detailPath: function (productId) {
                var me = this;
                var msg = {
                    showClose: true,
                    message: '系統運作有誤，請重新操作或請聯繫維運人員',
                    type: 'warning'
                };
                location.href = me.urls.detailPath + '?productId=' + productId;
            },
            updatePath: function () {
                var me = this;
                var msg = {
                    showClose: true,
                    message: '系統運作有誤，請重新操作或請聯繫維運人員',
                    type: 'warning'
                };

                window.axios.post(me.urls.updateProduct,
                    {
                        ProductId: me.productList.ProductId,
                        ProductName: me.filter.name,
                        Price: me.filter.price,
                        Quantity: me.filter.quantity,
                        CanSale: me.filter.canSale
                    },
                ).then(function (response) {
                    me.resultData = response.data.users;
                    me.pagination.pageSize = response.data.pageSize;
                    me.pagination.currentPage = 1;
                    me.pagination.total = response.data.tableRowTotal;
                    me.domOperation.screenLoading = false;
                }).catch(function (response) {
                    console.log(response);
                    me.domOperation.screenLoading = false;
                    msg.message = '資料傳遞發生錯誤，請稍後再試！';
                    me.$message(msg);
                });

            }
            /*
             * get detail
             * @param {} row 
             */
        }
    });
})();