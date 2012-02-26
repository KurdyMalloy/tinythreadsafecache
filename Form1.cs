using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TinyThreadSafeCache
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshCacheSize();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyCache.Instance.Purge();
            RefreshCacheSize();
        }

        private void RefreshCacheSize()
        {
            label2.Text = MyCache.Instance.Size().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyTypeToCache item = new MyTypeToCache();
            item.s1 = textBox2.Text;
            item.s2 = textBox3.Text;
            item.s3 = textBox4.Text;

            MyCache.Instance.Add(textBox1.Text, item);
            
            RefreshCacheSize();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyTypeToCache item = MyCache.Instance.Get(textBox1.Text);
            if (item != null)
            {
                textBox2.Text = item.s1;
                textBox3.Text = item.s2;
                textBox4.Text = item.s3;
            }
            else
            {
                MessageBox.Show("No item matches that key in the cache!");
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
            }
            RefreshCacheSize();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MyCache.Instance.Delete(textBox1.Text);
            RefreshCacheSize();
        }
    }
}
