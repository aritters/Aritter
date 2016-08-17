(function () {
  'use strict';

  function Layout() {
    return {
      restrict: 'E',
      replace: true,
      transclude: true,
      controller: 'LayoutController',
      controllerAs: '$layout',
      templateUrl: 'app/shared/layout/layout.html',
      require: ['^maApp', 'maLayout'],
      link: function (scope, elem, attrs, ctrls) {
        var $layout = ctrls[1];
        $layout.menuItems = (scope.$eval(attrs.menuItems || '') || []);
        $layout.chatUsers = (scope.$eval(attrs.chatUsers || '') || []);
        $layout.logout = attrs.logout;
      }
    };
  }

  angular.module('materialAdmin')
    .directive('maLayout', [Layout]);
})();
