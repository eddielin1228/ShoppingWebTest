(function () {
    var app = new Vue({
        el: '#app',
        data: {
            cartList: [],
            totalPrice : 0,
            urls: {
                createOrderPath: window.injectObj.urls.createOrderPath || '',
                homePath: window.injectObj.urls.homePath || ''
            },
            productList: window.injectObj.productList,
        },
        methods: {
            /*
            * 寫入訂單
            */
            checkout: function () {
                var me = this;
                window.axios.post(me.urls.createOrderPath,
                    {
                        TotalPrice: me.totalPrice,
                        OrderItems: me.productList
                    }
                ).then(function (response) {
                    if (response.data.success) {
                        me.deleteCart();
                    } else {
                        alert(response.data.message);
                    }
                }).catch(function (response) {
                    console.log(response);
                    alert("資料傳遞發生錯誤，請稍後再試！");
                });
            },
            /*
             * 刪除購物車
             */
            deleteCart: function () {
                window.localStorage.removeItem("cartList");
            },
            /*
             * 取得總金額
             */
            getTotalPrice: function () {
                var me = this;
                me.productList.forEach(x => {
                    me.totalPrice += x.Count * x.Price;
                });
            }
        }
    });
    app.getTotalPrice();
    app.checkout();
})();