(function () {
    var app = new Vue({
        el: '#app',
        data: {
            cartList: [],
            urls: {
                detailPath: window.injectObj.urls.detailPath || ''
            },
            productList: window.injectObj.productList,
        },
        methods: {
            /*
            * 新增購物車
            */
            addCart: function () {
                var me = this;
                var canAddCart = true;
                me.productList.forEach(x => {
                    if (x.isBuy) {
                        if (x.Count > 0 && x.Count <= x.Quantity) {
                            me.cartList.push(x);
                        } else {
                            canAddCart = false;
                        }
                    }
                });
                console.log(me.cartList);
                console.log(canAddCart);
                if (canAddCart) {
                    window.localStorage.setItem("cartList", JSON.stringify(me.cartList).toString());
                    if (me.cartList.length > 0) {
                        alert("已加入購物車");
                        setTimeout(function () { location.reload(); }, 1000);
                    } else {
                        alert("無可加入購物車之商品");
                    }
                } else {
                    alert("訂購數量不可為0或大於庫存數量");
                }


            }
        }
    });
})();