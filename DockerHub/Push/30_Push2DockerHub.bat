docker images

pause

set IMAGE_ID_STR=
set /p IMAGE_ID_STR="�Ώ�(mvcsample:latest)�̃C���[�WID�����: "
echo ���͂����C���[�WID: %IMAGE_ID_STR%

pause

docker tag %IMAGE_ID_STR% osscjpdevinfra/mvcsample:MVCSampleOnDocker
docker images

pause

docker login

pause

docker push osscjpdevinfra/mvcsample:MVCSampleOnDocker

pause
