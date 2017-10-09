var app = getApp();
Page({

  /**
   * 页面的初始数据
   */
  data: {
    userName: null,
    isShow: false,
    imgUrls: [
      'http://img02.tooopen.com/images/20150928/tooopen_sy_143912755726.jpg',
      'http://img06.tooopen.com/images/20160818/tooopen_sy_175866434296.jpg',
      'http://img06.tooopen.com/images/20160818/tooopen_sy_175833047715.jpg'
    ],
    datas: [
      { "txt": '[评测]Samsung S8', "src": "../../images/img/s8.jpg" },
      { "txt": '[开箱]Meizu Pro7', "src": "../../images/img/pro7.jpg" },
      { "txt": '[图赏]Sony Xparia XZ Premium', "src": "../../images/img/xzp.jpg" },
      { "txt": '[上手]HTC U11', "src": "../../images/img/u11.jpg" },
    ],
    listItems: ['[评测]SmartTisian M1', '[评测]SmartTisian M1', '[评测]SmartTisian M1', '[评测]SmartTisian M1']
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {    
    var that = this;
    if (app.globalData.userInfo == null) {
      wx.redirectTo({
        url: '../login/login',
      })
    }
    else {
      console.log("我进来了");
      that.setData({ userName: app.globalData.userInfo.realName, isShow: true });
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