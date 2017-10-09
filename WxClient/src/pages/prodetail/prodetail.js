Page({
  data: {
    photoList: null,
    product: null
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    var that = this;
    var id = options.ProID;
    if (id > 0) {     
      wx.request({
        url: 'http://40.71.87.251:84/api/Products/GetProductByID',
        data: {
          ProID: id
        },
        header: {
          'content-type': 'application/json'
        },
        success: function (res) {
          console.info(res);
          if (res.statusCode == 200) {
            var array = new Array();
            array[0] = res.data.photoSrc;
            array[1] = res.data.photoSrc;
            array[2] = res.data.photoSrc;
            array[3] = res.data.photoSrc;
            that.setData({ product: res.data, photoList: array })
          }
        }
      })
    }

  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  }
})