(function () {
    var app = new Vue({
        el: '#app',
        data: {
            cartList: [],
            urls: {
                createProduct: window.injectObj.urls.createProduct || '',
                detailPath: window.injectObj.urls.detailPath || '',
                checkoutPath: window.injectObj.urls.checkoutPath || ''
            },
            productList: window.injectObj.productList,
        },
        methods: {
            /*
            * 更新購物車
            */
            updateCart: function () {
                var me = this;
                me.productList.forEach(x => {
                    if (x.isBuy && (x.Count > 0 && x.Count <= x.Quantity)) {
                        me.cartList.push(x);
                    }
                });
                window.localStorage.setItem("cartList", JSON.stringify(me.cartList).toString());
                setTimeout(function () { location.reload(); }, 1000);
            },
            /*
             * 清除購物車
             */
            deleteCart: function () {
                window.localStorage.removeItem("cartList");
                setTimeout(function () { location.reload(); }, 1000);
            },
            /*
            * 轉頁至結帳頁面
            */
            checkoutPath: function () {
                var me = this;
                me.updateCart();
                location.href = me.urls.checkoutPath;
            }
        }
    });
})();