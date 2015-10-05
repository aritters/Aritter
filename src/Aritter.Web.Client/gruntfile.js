/// <binding BeforeBuild='build' />
module.exports = function (grunt) {

  require('load-grunt-tasks')(grunt);
  grunt.loadNpmTasks('grunt-contrib-clean');
  grunt.loadNpmTasks('grunt-contrib-uglify');
  grunt.loadNpmTasks('grunt-contrib-less');
  grunt.loadNpmTasks('grunt-angular-templates');
  grunt.loadNpmTasks('grunt-contrib-watch');
  grunt.loadNpmTasks('grunt-injector');

  grunt.initConfig({
    pkg: grunt.file.readJSON('package.json'),
    jshint: {
      options: {
        jshintrc: '.jshintrc'
      },
      all: ['wwwroot/app/**/*.js', '!wwwroot/app/**/*min.js']
    },
    clean: {
      build: {
        src: ['wwwroot/app/**/*.min.js', 'wwwroot/app/**/*.min.js.map', 'wwwroot/assets/css/aritter.min.css']
      }
    },
    uglify: {
      options: {
        sourceMap: true,
        sourceMapIncludeSources: true
      },
      build: {
        files: [{
          expand: false,
          src: ['wwwroot/app/app.js', '!wwwroot/app/app.min.js'],
          dest: 'wwwroot/app/app.min.js'
        }, {
          expand: false,
          src: ['wwwroot/app/components/main/mainController.js', '!wwwroot/app/components/main/mainController.min.js'],
          dest: 'wwwroot/app/components/main/mainController.min.js'
        }, {
          expand: false,
          src: ['wwwroot/app/components/home/homeController.js', '!wwwroot/app/components/home/homeController.min.js'],
          dest: 'wwwroot/app/components/home/homeController.min.js'
        }]
      },
      publish: {
        files: {
          'wwwroot/app/aritter.min.js': ['wwwroot/app/**/*.js', '!wwwroot/app/**/*min.js']
        }
      }
    },
    injector: {
      options: {
        addRootSlash: false
      },
      build: {
        files: {
          'wwwroot/index.html': ['wwwroot/app/**/*min.js'],
        }
      },
      publish: {
        files: {
          'wwwroot/index.html': ['wwwroot/app/aritter.min.js'],
        }
      }
    },
    ngtemplates: {
      materialAdmin: {
        src: ['template/**.html', 'template/**/**.html'],
        dest: 'js/templates.js',
        options: {
          htmlmin: {
            collapseWhitespace: true,
            collapseBooleanAttributes: true
          }
        }
      }
    },
    less: {
      build: {
        options: {
          paths: ["css"]
        },
        files: {
          "css/app.css": "less/app.less",
        },
        cleancss: true
      }
    },
    watch: {
      styles: {
        files: ['less/**/*.less'], // which files to watch
        tasks: ['less', 'csssplit'],
        options: {
          nospawn: true
        }
      }
    }
  });

  grunt.registerTask('build', ['clean', 'jshint', 'uglify:build', 'injector:build']);
  grunt.registerTask('publish', ['clean', 'jshint', 'uglify:publish', 'injector:publish']);

  grunt.registerTask('default', ['watch']);
};
