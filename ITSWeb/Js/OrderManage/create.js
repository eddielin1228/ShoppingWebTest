(function () {
    var app = new Vue({
        el: '#app',
        data: {
            filter: {
                isBuy: false,
                name: '',
                price: '',
                quantity: '',
                canSale: true,
                address: ''
            },
            cartList: [],
            totalPrice : 0,
            urls: {
                createOrderPath: window.injectObj.urls.createOrderPath || '',
            },
            productList: window.injectObj.productList,
        },
        methods: {
            /*
            * change table page
            * @param {} val: 頁碼
            */
            chockout: function () {
                var me = this;
                var msg = {
                    showClose: true,
                    message: '系統運作有誤，請重新操作或請聯繫維運人員',
                    type: 'warning'
                };

                window.axios.post(me.urls.createOrderPath,
                    {
                        TotalPrice: me.totalPrice,
                        OrderItems: me.productList
                    },
                ).then(function (response) {
                    me.resultData = response.data.users;
                }).catch(function (response) {
                    console.log(response);
                    msg.message = '資料傳遞發生錯誤，請稍後再試！';
                    me.$message(msg);
                });
            },
            addCart: function () {
                var me = this;
                me.productList.forEach(x => {
                    if (x.isBuy && x.Count > 0 && x.Count <= x.quantity) {
                        me.cartList.push(x);
                    }
                });
                window.localStorage.setItem("cartList", JSON.stringify(me.cartList).toString());
            },
            deleteCart: function () {
                window.localStorage.removeItem("cartList");
            },
            getTotalPrice: function () {
                var me = this;
                me.productList.forEach(x => {
                    me.totalPrice += x.Count * x.Price;
                });
            }
        }
    });
    app.getTotalPrice();
})();