using UnityEditor.ShaderGraph;
using UnityEngine;

public class BounceMushroom : MonoBehaviour
{
    [SerializeField] private float bounceForce = 10f;  // Độ bật

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra xem object va chạm có tag "Player" hay không
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Đã chạm với nấm 1");
            // Lấy Rigidbody2D của Player
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null && collision.contacts.Length > 0)
            {
                // Cách 1: Thay đổi trực tiếp velocity trên trục Y
                //playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, bounceForce);

                //Cách 2: Dùng AddForce
                playerRb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);


                //// Cách 3: Nhảy theo hướng của cây nấm
                //Vector2 normal = collision.contacts[0].normal;
                //// Kiểm tra nếu va chạm xảy ra từ phía trên của cây nấm
                //if (normal.y<-0.5f)
                //{
                //    Debug.Log("Đã chạm với mặt nấm");
                //    // Áp dụng vận tốc bật lên cho player
                //    playerRb.linearVelocity = normal * bounceForce;
                //}

            }
        }
    }
}
