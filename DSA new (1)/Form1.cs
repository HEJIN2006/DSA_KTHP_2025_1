using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_new

{
    public partial class Form1 : Form
    {
        public class Node
        {
            public int ID;
            public string UserName;
            public string Content;
            public Node Next;

            public Node(int id, string user, string content)
            {
                ID = id;
                UserName = user;
                Content = content;
                Next = null;
            }            
            public Node(string content)
            {
                
                    ID = -1;            
                    UserName = "";     
                    Content = "";       
                    Next = null;
                

            }
        }

        private Node head = new Node("Header");  
        private int nextID = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDang_Click(object sender, EventArgs e)
        {
            string userName = txtTenNguoiDang.Text;
            string content = txtNoiDung.Text;

            if (userName != null && content != null && userName != "" && content != "")
            {
                Node newPost = new Node(nextID, userName, content);
                nextID++;
                Node temp = head;
                while (temp.Next != null)
                    temp = temp.Next;
                temp.Next = newPost;

                DisplayPosts();
                txtTenNguoiDang.Text = "";
                txtNoiDung.Text = "";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id;
            bool isValid = ConvertToInt(txtNhapID.Text, out id);
            if (!isValid) return;

            if (head == null) return;

            if (head.ID == id)
                head = head.Next;
            else
            {
                Node temp = head;
                while (temp.Next != null && temp.Next.ID != id)
                    temp = temp.Next;
                if (temp.Next != null)
                    temp.Next = temp.Next.Next;
            }

            DisplayPosts();
            txtNhapID.Text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchText = txtNhapID.Text;
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Vui lòng nhập ID !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           
            listBoxNoiDung.Items.Clear();
            Node temp = head;
            bool found = false;

            while (temp != null)
            {
                int tempID;
                if (ConvertToInt(searchText, out tempID) && temp.ID == tempID)
                {
                    listBoxNoiDung.Items.Add("ID: " + temp.ID + " | " + temp.UserName + ": " + temp.Content);
                    found = true;
                    break;
                }
                
                temp = temp.Next;
            }

            if (!found)
                listBoxNoiDung.Items.Add("Không tìm thấy bài viết!");
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            int postId;
            if (!ConvertToInt(txtNhapID.Text, out postId)) return;

            string newUserName = txtTenNguoiDang.Text;
            string newContent = txtNoiDung.Text;

            if (newUserName == null || newUserName == "" || newContent == null || newContent == "") return;

            Node temp = head;
            bool found = false;

            while (temp != null)
            {
                if (temp.ID == postId)
                {
                    temp.UserName = newUserName;
                    temp.Content = newContent;
                    found = true;
                    break;
                }
                temp = temp.Next;
            }

            if (found)
            {
                DisplayPosts();
                txtNhapID.Text = "";
                txtTenNguoiDang.Text = "";
                txtNoiDung.Text = "";
            }
        }

        private void DisplayPosts()
        {
            listBoxNoiDung.Items.Clear();
            Node temp = head.Next;  
            while (temp != null)
            {
                listBoxNoiDung.Items.Add("ID: " + temp.ID + " | " + temp.UserName + ": " + temp.Content);
                temp = temp.Next;
            }
        }

        private bool ConvertToInt(string text, out int number)
        {
            number = 0;
            if (text == null || text == "") return false;

            int result = 0;
            bool isNumeric = true;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c < '0' || c > '9')
                {
                    isNumeric = false;
                    break;
                }
                result = result * 10 + (c - '0');
            }
            number = result;
            return isNumeric;
        }
        private void txtNhapID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNhapID.Text) && !int.TryParse(txtNhapID.Text, out _))
            {
                MessageBox.Show(" ID phải là một số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapID.Clear(); 
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            DisplayPosts();
            txtNhapID.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void picBoxAnh_Click(object sender, EventArgs e) { }
        private void lblID_Click(object sender, EventArgs e) { }

        private void lblNoiDung_Click(object sender, EventArgs e) { }

        private void lblNhapten_Click(object sender, EventArgs e) { }
       

        private void listBoxNoiDung_SelectedIndexChanged(object sender, EventArgs e) { }

        private void txtTenNguoiDang_TextChanged(object sender, EventArgs e) { }

        private void txtNoiDung_TextChanged(object sender, EventArgs e) { }

       

        private void lblBaiVietGanDay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã nhấn vào Bài viết gần đây!");
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }

}



