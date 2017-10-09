var app=getApp();
Page({
  /**
   * 页面的初始数据
   */
  data: {
    userName: null,
    pwd: null
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {

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

  },
  inputInfo: function (e) {
    var that = this;
    var inputType = e.target.dataset.type;
    var val = e.detail.value;
    if (inputType == "uName") {
      that.setData({ userName: val })
    }
    else if (inputType == "uPwd") {
      that.setData({ pwd: val })
    }
  },
  Login: function (e) {
    var that = this;
    console.info(that.data.userName, that.data.pwd);
    if (that.data.userName != "" && that.data.pwd != "") {
      wx.request({
        url: 'http://40.71.87.251:84/api/Users/Login',
        data: {
          userName: that.data.userName,
          pwd: that.data.pwd
        },
        header: {
          "Content-Type": "application/x-www-form-urlencoded"  
        },
        method: "POST",  
        success: function (res) {
          if (res.statusCode==200){
            app.globalData.userInfo=res.data;
            console.info(app.globalData.userInfo);
            wx.setStorage({
              key: 'userInfo',
              data: res.data,
              success:function(){
                console.info("用户登录成功，存储信息，跳转至首页....");
                wx.switchTab({
                  url: '../index/index'
                })
              }
            })
          }          
        }
      })
    }
  }
})