var Admin = {};
$(function () {
    Admin.load = function () {
        Admin.addMsg('系统加载完成...');
    };
    Admin.addMsg = function (msg) {
        $('#span_Admin_msg').text(msg);
        $('#span_Admin_msgtime').text('(' + new Date().toLocaleTimeString() + ')');
        Admin.msgCount++;
    };
    Admin.addTabs = function (tabindex,title, url) {
        var tab = $('#' + tabindex);
        if (tab.tabs('exists', title)) {
            tab.tabs('select', title);
            /* var tabindex = tab.tabs('getSelected');
            tabindex.panel('refresh');*/
        }
        else {
            tab.tabs('add', {
                closable: true,
                title: title,
                href: url
            });
        }
    };
    Admin.addTabs2 = function (title, url) {
        var tab = $('#tabs_Admin2');
        if (tab.tabs('exists', title))
            tab.tabs('select', title);
        else {
            tab.tabs('add', {
                closable: true,
                title: title,
                href: url
            });
        }
    };
    Admin.addTabs3 = function (title, url) {
        var tab = $('#tabs_Admin3');
        if (tab.tabs('exists', title)){
            tab.tabs('select', title);
            /*var tabindex = tab.tabs('getSelected');
            tabindex.panel('refresh');*/
        }
        else {
            tab.tabs('add', {
                closable: true,
                title: title,
                href: url
            });
        }
    };
    Admin.addTabs4 = function (title, url) {
        var tab = $('#tabs_Admin4');
        if (tab.tabs('exists', title))
            tab.tabs('select', title);
        else {
            tab.tabs('add', {
                closable: true,
                title: title,
                href: url
            });
        }
    };
    Admin.addTabs5 = function (title, url) {
        var tab = $('#tabs_Admin5');
        if (tab.tabs('exists', title))
            tab.tabs('select', title);
        else {
            tab.tabs('add', {
                closable: true,
                title: title,
                href: url
            });
        }
    };
    Admin.addTabs6 = function (title, url) {
        var tab = $('#tabs_Admin6');
        if (tab.tabs('exists', title))
            tab.tabs('select', title);
        else {
            tab.tabs('add', {
                closable: true,
                title: title,
                href: url
            });
        }
    };
    Admin.addTabs7 = function (title, url) {
        var tab = $('#tabs_Admin7');
        if (tab.tabs('exists', title))
            tab.tabs('select', title);
        else {
            tab.tabs('add', {
                closable: true,
                title: title,
                href: url
            });
        }
    };
    Admin.init = function () {
        Admin.load();
    };
    Admin.init();
    //退出
    $('#login_out').click(function () {
        $.ajax({
            type: "Post",
            url: "/Account/LoginOut",
            data: { },
            dataType: "json",
            beforeSend: function () {

            },
            success: function (data) {

                if (data.Status == 1) {
                    window.location.href = "Account\\Login";
                }
                else {
                    $.messager.alert('提示', data.ErroMessage);
                }
            },
            error: function (XmlHttpRequest, textStatus, errorThrown) {
                alert(XmlHttpRequest.responseText);
            }
        });
    });
    getCurrentUserName();
});
function getCurrentUserName() {
    $.ajax({
        type: "Post",
        url: "/Account/getCurrentUserName",
        data: {},
        dataType: "json",
        beforeSend: function () {

        },
        success: function (data) {
            if (data.Status == 1) {
                $('#userName').html(data.Data);
            }
        },
        error: function (XmlHttpRequest, textStatus, errorThrown) {
            alert(XmlHttpRequest.responseText);
        }
    });
}
$('#pop_up_box').click(function () {
    $('#mask').css("display", "block");
    $('#box').css("display", "block");
})
$('#box_btn').click(function () {
    $('#mask').css("display", "none");
    $('#box').css("display", "none");
})

