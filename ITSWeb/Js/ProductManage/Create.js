(function () {
    var app = new Vue({
        el: '#app',
        data: {
            filter: {
                name: '',
                price: '',
                quantity: '',
                canSale: true,
                address: '',
                fileUpload:''
            },
            urls: {
                createProduct: window.injectObj.urls.createProduct || '',
            },
            formData: new FormData()
        },
        methods: {
            /*
            * 建立商品
            */
            createData: function () {
                var me = this;
                var msg = {
                    showClose: true,
                    message: '系統運作有誤，請重新操作或請聯繫維運人員',
                    type: 'warning'
                };

                var formData = me.formData;
                formData.append('ProductName', me.filter.name);
                formData.append('Price', me.filter.price);
                formData.append('Quantity', me.filter.quantity);
                formData.append('CanSale', me.filter.canSale);

                window.axios.post(me.urls.createProduct,
                    formData
                ).then(function (response) {
                    me.resultData = response.data.users;
                    setTimeout(function () { location.reload(); }, 1000);
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
            },
        }
    });
})();