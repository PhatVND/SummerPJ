using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_script : MonoBehaviour
{

    [SerializeField] private textWriter textWriter; // do this to set a reference to a script, put textWriter script in GameObject;

    private Text messageText;

    public bool isWave2 = false;
    public bool isWave5 = false;
    public bool isWave14 = false;

    private void Awake()
    {
        messageText = transform.Find("message").Find("messageText").GetComponent<Text>();
    }
    private void Start()
    {
       
    
        if (isWave2) {
            textWriter.AddWriter(messageText, "Bạn có thể xem hiện đang là Wave nào bên tay trái. Đối với những Wave là số chẵn, sẽ có thêm những loài rồng.... rất nhanh.. Nào, hãy chặn bọn chúng lại!!", 0.05f);
        }
        else if (isWave5)
        {
            textWriter.AddWriter(messageText, "Tiêu diệt rồng sẽ có 50% nhận được Dragon Fragments (DF), bạn có thể dùng nó để Mua thêm các Turret mới. Với những Wave là bội số của 5, sẽ có thêm những loài rồng khá trâu (nhưng khá chậm, haha)", 0.05f);

        }
        else if (isWave14)
        {
            textWriter.AddWriter(messageText, "Nóng quá... Tôi nghĩ Vua rồng đã nổi giận rồi, hãy mua Turret chuyên dụng (Màu cam) để tiêu diệt Vua rồng và Rồng con nhé.. Cố lên nào, bạn tôi.", 0.05f);

        }
        else
        {
            textWriter.AddWriter(messageText, "Chào mừng bạn đến với Draslay - trò chơi Tower Defense. Tôi là trợ lý của bạn,... hmm... nói sau đi nhé, hãy mau đặt các Turret ra để tiêu diệt kẻ địch nào, đừng cho bọn chúng tiến vào nhà chúng ta.", 0.05f);
        }

    }
}
