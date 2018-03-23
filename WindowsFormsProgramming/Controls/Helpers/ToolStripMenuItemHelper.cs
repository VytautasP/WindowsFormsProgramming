using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProgramming.Controls.Helpers
{
    public static class ToolStripMenuItemHelper 
    {
        public static ToolStripMenuItem CloneToolStripMenuItem(ToolStripMenuItem itemToClone)
        {

            ToolStripMenuItem clonedItem = new ToolStripMenuItem();

            PropertyInfo itemToClonePropertyInfo = itemToClone.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList itemToCloneEventHandlerList = (EventHandlerList)itemToClonePropertyInfo.GetValue(itemToClone, null);

            PropertyInfo clonedItemPropertyInfo = clonedItem.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);

            EventHandlerList clonedItemEventHandlerList = (EventHandlerList)clonedItemPropertyInfo.GetValue(clonedItem, null);

            clonedItemEventHandlerList.AddHandlers(itemToCloneEventHandlerList);

            clonedItem.AccessibleName = itemToClone.AccessibleName;
            clonedItem.AccessibleRole = itemToClone.AccessibleRole;
            clonedItem.Alignment = itemToClone.Alignment;
            clonedItem.AllowDrop = itemToClone.AllowDrop;
            clonedItem.Anchor = itemToClone.Anchor;
            clonedItem.AutoSize = itemToClone.AutoSize;
            clonedItem.AutoToolTip = itemToClone.AutoToolTip;
            clonedItem.BackColor = itemToClone.BackColor;
            clonedItem.BackgroundImage = itemToClone.BackgroundImage;
            clonedItem.BackgroundImageLayout = itemToClone.BackgroundImageLayout;
            clonedItem.Checked = itemToClone.Checked;
            clonedItem.CheckOnClick = itemToClone.CheckOnClick;
            clonedItem.CheckState = itemToClone.CheckState;
            clonedItem.DisplayStyle = itemToClone.DisplayStyle;
            clonedItem.Dock = itemToClone.Dock;
            clonedItem.DoubleClickEnabled = itemToClone.DoubleClickEnabled;
            clonedItem.Enabled = itemToClone.Enabled;
            clonedItem.Font = itemToClone.Font;
            clonedItem.ForeColor = itemToClone.ForeColor;
            clonedItem.Image = itemToClone.Image;
            clonedItem.ImageAlign = itemToClone.ImageAlign;
            clonedItem.ImageScaling = itemToClone.ImageScaling;
            clonedItem.ImageTransparentColor = itemToClone.ImageTransparentColor;
            clonedItem.Margin = itemToClone.Margin;
            clonedItem.MergeAction = itemToClone.MergeAction;
            clonedItem.MergeIndex = itemToClone.MergeIndex;
            clonedItem.Name = itemToClone.Name;
            clonedItem.Overflow = itemToClone.Overflow;
            clonedItem.Padding = itemToClone.Padding;
            clonedItem.RightToLeft = itemToClone.RightToLeft;
            clonedItem.ShortcutKeys = itemToClone.ShortcutKeys;
            clonedItem.ShowShortcutKeys = itemToClone.ShowShortcutKeys;
            clonedItem.Tag = itemToClone.Tag;
            clonedItem.Text = itemToClone.Text;
            clonedItem.TextAlign = itemToClone.TextAlign;
            clonedItem.TextDirection = itemToClone.TextDirection;
            clonedItem.TextImageRelation = itemToClone.TextImageRelation;
            clonedItem.ToolTipText = itemToClone.ToolTipText;
            clonedItem.Available = itemToClone.Available;

            foreach (ToolStripMenuItem dropDownItem in itemToClone.DropDownItems)
            {
                clonedItem.DropDownItems.Add(CloneToolStripMenuItem(dropDownItem));
            }


            if (!itemToClone.AutoSize)
            {
                clonedItem.Size = itemToClone.Size;
            }

            return clonedItem;
        }
    }
}
