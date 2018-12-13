pipeline {
  agent any

  options {
    timestamps()
  }

  stages {
    stage('Checkout') {
      steps {
        checkout scm
      }
    }
    stage('Build') {
      steps {
        bat "\"${tool 'MSBuild 150 x86'}\" MultiRename.sln /p:Configuration=Release"
      }
    }
  }

  post {
    always {
      emailext( body: "<p>Check console output at <a href='${env.BUILD_URL}'>${env.JOB_NAME} [${env.BUILD_NUMBER}]</a></p>",
                subject: "${env.BUILD_STATUS}: Job '${env.JOB_NAME} [${env.BUILD_NUMBER}]'",
                to: "iulian.iliescu@cerner.com")
    }
  }
}