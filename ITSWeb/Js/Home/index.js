(function () {
    var app = new Vue({
        el: '#app',
        data: {
            filter: {
                isBuy:false,
                name: '',
                price: '',
                quantity: '',
                canSale:true,
                address:''
            },
            cartList:[],
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
            addCart: function () {
                var me = this;
                me.productList.forEach(x => {
                    if (x.isBuy && (x.Count > 0 && x.Count<=x.Quantity)) {
                        me.cartList.push(x);
                    }
                });
                window.localStorage.setItem("cartList", JSON.stringify(me.cartList).toString());
                setTimeout(function () { location.reload(); }, 1000);
                
            }
        }
    });
})();