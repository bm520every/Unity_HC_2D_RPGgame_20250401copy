using UnityEngine;

public class ControlSystem : MonoBehaviour
{
    //�ܼ�:�x�s�C������ơA�Ҧp:��q�B���ʳt�׵����C
    //�ܼƻy�k
    //�׹��� ������� �ܼƦW��;
    //ex:(private float moveSpeed;)
    //�ŧi�@���ܼơA�W�٥s�����ʳt�סA�����O�B�I��(�i�s�񦳤p���I���)
    private float moveSpeed;
    // ������:�����B����
    // ����ƥ�:�Ĥ@�Ӱ��檺�ƥ�A����@��
    private void Awake()
    {
        Debug.Log("Hello~");
    }
    // �}�l�ƥ�:�b��������@��
    private void Start()
    {
        Debug.Log("<color=red>�}�l�ƥ�</color>");
    }
    // ��s�ƥ�:�b�}�l�ƥ��C�������60��
    private void Update()
    {
        Debug.Log("<color=yellow>��s�ƥ�</color>");
    }
}
