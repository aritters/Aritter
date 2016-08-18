(function () {
  'use strict';

  function LayoutController($scope, $state) {
    var self = this;

    self.$state = $state;

    self.currentSkin = localStorage.getItem('ma-current-skin') || 'blue';

    self.sidebarToggled = false;
    self.chatToggled = false;
    self.profileMenuToggled = false;

    self.chatUsers = [];
    self.menuItems = [];

    self.skinList = [
      'lightblue',
      'bluegray',
      'cyan',
      'teal',
      'green',
      'orange',
      'blue',
      'purple'
    ];

    self.resetSidebar = function (event) {
      if (!angular.element(event.target).parent().hasClass('active')) {
        self.sidebarToggled = false;
      }
    };

    self.skinSwitch = function (skin) {
      self.currentSkin = skin;
      localStorage.setItem('ma-current-skin', skin);
    };
  }

  angular.module('aritter')
    .controller('LayoutController', ['$scope', '$state', LayoutController]);
})();