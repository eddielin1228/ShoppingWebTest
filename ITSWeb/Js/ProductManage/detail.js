(function () {
    var app = new Vue({
        el: '#app',
        data: {
            filter: {
                name: window.injectObj.productList.ProductName || '',
                price: window.injectObj.productList.Price || '',
                quantity: window.injectObj.productList.Quantity || '',
                canSale: window.injectObj.productList.CanSale,
                address: window.injectObj.productList.Address||''
            },
            urls: {
                updateProduct: window.injectObj.urls.updateProduct || '',
                detailPath: window.injectObj.urls.detailPath || ''
            },
            productList: window.injectObj.productList,
            formData: new FormData()

        },
        methods: {
            updatePath: function () {
                var me = this;
                var msg = {
                    showClose: true,
                    message: '系統運作有誤，請重新操作或請聯繫維運人員',
                    type: 'warning'
                };
                var formData = me.formData;
                formData.append('ProductId', me.productList.ProductId);
                formData.append('ProductName', me.filter.name);
                formData.append('Price', me.filter.price);
                formData.append('Quantity', me.filter.quantity);
                formData.append('CanSale', me.filter.canSale);

                window.axios.post(me.urls.updateProduct,
                    formData
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

            },
            onUploadChange(event) {
                var file = event.target.files[0];
                var me = this;
                var msg = {
                    showClose: true,
                    message: '系統運作有誤，請重新操作或請聯繫維運人員',
                    type: 'warning',
                    duration: 2000
                };
                if (!file) {
                    return;
                }
                if (file !== 'undefined' && file.name.indexOf('.') === -1) {
                    msg.message = '檔案應有副檔名';
                    me.$message(msg);
                    return;
                }
                me.formData.append('FileUpload', file);
            }
        }
    });
})();