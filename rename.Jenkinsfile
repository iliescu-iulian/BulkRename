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
        bat "\"${tool 'MSBuild 150 x86'}\" MultiRename.sln /p:Configuration=Debug"
      }
    }
    stage('Unit Tests') {
      steps {
        bat 'D:\\dotcover\\dotcover.exe cover /output="coverage/tests.dcvr" /TargetExecutable="D:\\VS12\\Common7\\IDE\\MSTest.exe" /TargetWorkingDir="MultiRename.Tests\\bin\\Debug" /TargetArguments="/testcontainer:MultiRename.Tests.dll" /Filters=-:module=*Test*'
        bat 'D:\\dotcover\\dotcover.exe report /source="coverage/tests.dcvr" /output:"coverage/index.html" /reporttype:HTML'
        publishHTML([allowMissing: true, alwaysLinkToLastBuild: false, keepAll: true, reportDir: 'coverage', reportFiles: 'index.html', reportName: 'Coverage', reportTitles: 'BulkRename'])
        xunit thresholds: [failed()], tools: [MSTest(deleteOutputFiles: true, failIfNotNew: false, pattern: '**/*', skipNoTestFiles: true, stopProcessingIfError: true)]

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