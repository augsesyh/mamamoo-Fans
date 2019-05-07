$("#slider").slider({
    width: 400, // width
    height: 40, // height
    sliderBg: "rgba(230,245,188)", // 滑块背景颜色
    color: "black", // 文字颜色
    fontSize: 14, // 文字大小
    bgColor: "rgba(78,226,153,0.40)", // 背景颜色
    textMsg: "请按住滑块，拖动到最右边", // 提示文字
    successMsg: "验证通过", // 验证成功提示文字
    successColor: "black", // 滑块验证成功提示文字颜色
    time: 400, // 返回时间
    callback: function (result) {
        if (result) {
            ;　　　　　//你想干啥
        })
            }
// 回调函数，true(成功),false(失败)
        }
    });
