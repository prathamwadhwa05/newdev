pipeline {
    agent any
    environment {
        IMAGE_NAME = 'pratham5425/dotnetapitest'
        IMAGE_TAG = '1.2'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build'
            }
        }
    stage('Test') {
            steps {
                sh 'dotnet test'
            }
        }
         stage('Docker Build') {
            steps {
                script {
                    docker.build("${IMAGE_NAME}:${IMAGE_TAG}")
                }
            }
        }

        stage('Docker Push') {
            steps {
                script {
                    docker.withRegistry('https://index.docker.io/v1/', 'docker_login') {
                        docker.image("${IMAGE_NAME}:${IMAGE_TAG}").push()
                    }
                }
            }
        }

        stage('Run container') {
            steps {
                script {
                   sh 'docker stop dotnetapicontainer'
                    sh 'docker rm dotnetapicontainer'
                    sh "docker run -d --name dotnetapicontainer -p 8055:80 ${IMAGE_NAME}:${IMAGE_TAG}"
                }

            }
        }
    }
}
