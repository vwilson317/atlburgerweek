using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace AtlBurgerWeekAppAndroid
{
    class ExpandableListAdapter : BaseExpandableListAdapter
    {
        Context context;
        private readonly List<Java.Lang.String> headers;
        private readonly Dictionary<Java.Lang.String, Java.Util.ArrayList> childItems;

        public ExpandableListAdapter(Context context, List<Java.Lang.String> headers, Dictionary<Java.Lang.String, Java.Util.ArrayList> childItems)
        {
            this.context = context;
            this.headers = headers;
            this.childItems = childItems;
        }

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            var key = headers.ElementAt(groupPosition);
            return childItems[key];
        }

        public override long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public override int GetChildrenCount(int groupPosition)
        {
            return childItems[headers[groupPosition]].Size();
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            //Java.Lang.String childText = (Java.Lang.String)GetChild(groupPosition, childPosition);

            if (convertView == null)
            {
                LayoutInflater infalInflater = (LayoutInflater)this.context
                        .GetSystemService(Context.LayoutInflaterService);
                convertView = infalInflater.Inflate(Resource.Layout.list_item, null);
            }

            TextView txtListChild = (TextView)convertView
                    .FindViewById(Resource.Id.lblListItem);

            //txtListChild.SetText(childText);
            return convertView;
        }

        public override Java.Lang.Object GetGroup(int groupPosition)
        {
            return this.headers[groupPosition];
        }
        
        public override long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            //Java.Lang.String headerTitle = (Java.Lang.String)GetGroup(groupPosition);
            if (convertView == null)
            {
                LayoutInflater infalInflater = (LayoutInflater)this.context
                        .GetSystemService(Context.LayoutInflaterService);
                convertView = infalInflater.Inflate(Resource.Layout.list_group, null);
            }

            TextView lblListHeader = (TextView)convertView
                    .FindViewById(Resource.Id.lblListHeader);
            lblListHeader.SetTypeface(null, Android.Graphics.TypefaceStyle.Bold);
            //lblListHeader.Set(headerTitle);

            return convertView;
        }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        public override int GroupCount => throw new NotImplementedException();

        public override bool HasStableIds => false;
    }

    class ExpandableListAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}

//package info.androidhive.expandablelistview;

//import java.util.HashMap;
//import java.util.List;

//import android.content.Context;
//import android.graphics.Typeface;
//import android.view.LayoutInflater;
//import android.view.View;
//import android.view.ViewGroup;
//import android.widget.BaseExpandableListAdapter;
//import android.widget.TextView;

//public class ExpandableListAdapter extends BaseExpandableListAdapter
//{


//    private Context _context;
//private List<String> _listDataHeader; // header titles
//                                      // child data in format of header title, child title
//private HashMap<String, List<String>> _listDataChild;

//public ExpandableListAdapter(Context context, List<String> listDataHeader,
//        HashMap<String, List<String>> listChildData)
//{
//    this._context = context;
//    this._listDataHeader = listDataHeader;
//    this._listDataChild = listChildData;
//}

//@Override
//    public Object getChild(int groupPosition, int childPosititon)
//{
//    return this._listDataChild.get(this._listDataHeader.get(groupPosition))
//            .get(childPosititon);
//}

//@Override
//    public long getChildId(int groupPosition, int childPosition)
//{
//    return childPosition;
//}

//@Override
//    public View getChildView(int groupPosition, final int childPosition,
//            boolean isLastChild, View convertView, ViewGroup parent)
//{

//    final String childText = (String)getChild(groupPosition, childPosition);

//    if (convertView == null)
//    {
//        LayoutInflater infalInflater = (LayoutInflater)this._context
//                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
//        convertView = infalInflater.inflate(R.layout.list_item, null);
//    }

//    TextView txtListChild = (TextView)convertView
//            .findViewById(R.id.lblListItem);

//    txtListChild.setText(childText);
//    return convertView;
//}

//@Override
//    public int getChildrenCount(int groupPosition)
//{
//    return this._listDataChild.get(this._listDataHeader.get(groupPosition))
//            .size();
//}

//@Override
//    public Object getGroup(int groupPosition)
//{
//    return this._listDataHeader.get(groupPosition);
//}

//@Override
//    public int getGroupCount()
//{
//    return this._listDataHeader.size();
//}

//@Override
//    public long getGroupId(int groupPosition)
//{
//    return groupPosition;
//}

//@Override
//    public View getGroupView(int groupPosition, boolean isExpanded,
//            View convertView, ViewGroup parent)
//{
//    String headerTitle = (String)getGroup(groupPosition);
//    if (convertView == null)
//    {
//        LayoutInflater infalInflater = (LayoutInflater)this._context
//                .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
//        convertView = infalInflater.inflate(R.layout.list_group, null);
//    }

//    TextView lblListHeader = (TextView)convertView
//            .findViewById(R.id.lblListHeader);
//    lblListHeader.setTypeface(null, Typeface.BOLD);
//    lblListHeader.setText(headerTitle);

//    return convertView;
//}

//@Override
//    public boolean hasStableIds()
//{
//    return false;
//}

//@Override
//    public boolean isChildSelectable(int groupPosition, int childPosition)
//{
//    return true;
//}
//}