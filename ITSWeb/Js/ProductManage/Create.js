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
                productManagePath: window.injectObj.urls.productManagePath
            },
            formData: new FormData()
        },
        methods: {
            /*
            * 建立商品
            */
            createData: function () {
                var me = this;
                var formData = me.formData;
                formData.append('ProductName', me.filter.name);
                formData.append('Price', me.filter.price);
                formData.append('Quantity', me.filter.quantity);
                formData.append('CanSale', me.filter.canSale);

                window.axios.post(me.urls.createProduct,
                    formData
                ).then(function (response) {
                    if (response.data.success) {
                        setTimeout(function () { location.href = me.urls.productManagePath; }, 1000);
                    } else {
                        alert(response.data.message);
                    }
                }).catch(function (response) {
                    console.log(response);
                    alert("資料傳遞發生錯誤，請稍後再試！");
                });
            },
            /*
             * 檔案上傳 處理
             */
            onUploadChange(event) {
                var file = event.target.files[0];
                console.log(file);
                var me = this;
                if (!file) {
                    return;
                }
                if (file.size > 4194304) {
                    alert("檔案不得超過4MB");
                    return;
                }
                if (file !== 'undefined' && file.name.indexOf('.') === -1) {
                    alert("檔案應有副檔名");
              return;
                }
                me.formData.append('FileUpload', file);
            },
        }
    });
})();