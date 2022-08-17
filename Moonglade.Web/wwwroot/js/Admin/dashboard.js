layui.use(['element', 'layer', 'util'], function () {
    var element = layui.element
        , layer = layui.layer
        , util = layui.util
        , $ = layui.$;

    //头部事件
    util.event('lay-header-event', {
        //左侧菜单事件
        menuLeft: function (othis) {
            layer.msg('展开左侧菜单的操作', { icon: 0 });
        }
        , menuRight: function () {
            layer.open({
                type: 1
                , content: '<div style="padding: 15px;">处理右侧面板的操作</div>'
                , area: ['260px', '100%']
                , offset: 'rt' //右上角
                , anim: 5
                , shadeClose: true
            });
        }
    });

});
function load_menu() {

    $.get({
        url: '/admin/Permission/GetMenuTree',
        beforeSend: function (xhr) {
            let token = localStorage.getItem("token");
            if (token !== null) {
                xhr.setRequestHeader('Authorization', 'Bearer ' + token);
            }
        },
    }).done((res) => {
        console.log('layout...', res);
        let htmls = '';
        if (res.code == 200) {
            res.data.forEach(function (item) {
                if (item.hasChildren) {
                    htmls += '<li class="layui-nav-item">';
                    htmls += '<a href="javascript:;">' + item.displayName + '</a>';
                    htmls += '<dl class="layui-nav-child">';
                    item.children.forEach(function (child) {
                        htmls += '<dd><a href="' + child.link + '">' + child.displayName + '</a></dd>';
                    })
                    htmls += '</dl></li>';
                } else {
                    htmls += '<li class="layui-nav-item"> <a href="' + item.link + '">' + item.displayName + '</a></li>';
                }
            });
        }
        var navele = document.getElementById('left_nav');
        console.log(navele);
        console.log(htmls);
        navele.innerHTML = htmls;
    });
}

load_menu();