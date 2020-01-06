(function () {
    var app = new Vue({
        el: '#app',
        data: {
            filter: {
                name: '',
                price: '',
                quantity: '',
                canSale:true,
                address:''
            },
            urls: {
                createProduct: window.injectObj.urls.createProduct || '',
                detailPath: window.injectObj.urls.detailPath || ''
            },
            productList:window.injectObj.productList,
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
                location.href = me.urls.detailPath+'?productId='+ productId;
            },
            /*
             * get detail
             * @param {} row 
             */
        }
    });
})();