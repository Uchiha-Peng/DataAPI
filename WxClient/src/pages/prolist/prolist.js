var app = getApp()
Page({
  /**
   * 页面的初始数据
   */
  data: {
    arrays:null,
    imgurl:'http://40.71.87.251:84/img/'
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad:function (options) {
    console.log("app onLoad");
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {
    // 非常重要
    var that = this;
    wx.request({
      url: 'http://40.71.87.251:84/api/Products/GetProducts',
      data: {},
      header: {
        'content-type': 'application/json'
      },
      success: function (res) {
        console.info(res);
        that.setData({ arrays: res.data })
      }
    })
  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {
    console.log("app onShow");
  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {
    console.log("app onHide");
  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {
    console.log("app onUnload");
  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {
    console.log("app onPullDownRefresh");
  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {
    console.log("app onReachBottom");
  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {
    console.log("app onShareAppMessage");
  },
  btnClick:function(event){
    console.log(event.target.dataset);
    wx.navigateTo({
      url: '../prodetail/prodetail?ProID=' + event.target.dataset.ProID,
    })

  }
})