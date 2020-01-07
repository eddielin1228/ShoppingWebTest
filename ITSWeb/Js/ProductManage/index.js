(function () {
    var app = new Vue({
        el: '#app',
        data: {
            urls: {
                createProduct: window.injectObj.urls.createProduct || '',
                detailPath: window.injectObj.urls.detailPath || '',
                deletePath: window.injectObj.urls.deletePath || ''
            },
            productList:window.injectObj.productList
        },
        methods: {
            /*
            * 轉頁至商品修改頁
            * @param {} productId: 商品ID
            */
            detailPath: function (productId) {
                var me = this;
                var msg = {
                    showClose: true,
                    message: '系統運作有誤，請重新操作或請聯繫維運人員',
                    type: 'warning'
                };
                location.href = me.urls.detailPath+'?productId='+ productId;
            },
            /*
             * 刪除商品
             */
            deleteProduct: function(productId) {
                var me = this;
                var msg = {
                    showClose: true,
                    message: '系統運作有誤，請重新操作或請聯繫維運人員',
                    type: 'warning'
                };
                window.axios.post(me.urls.deletePath, {
                    ProductId: productId
                }
                ).then(function (response) {
                    me.resultData = response.data.users;
                    setTimeout(function () { location.reload(); }, 1000);
                }).catch(function (response) {
                    console.log(response);
                    me.domOperation.screenLoading = false;
                    msg.message = '資料傳遞發生錯誤，請稍後再試！';
                    me.$message(msg);
                });
            }
        }
    });
})();