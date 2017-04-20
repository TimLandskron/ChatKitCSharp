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
using Android.Support.V7.Widget;

namespace ChatKitLibrary.Messages
{
    public class RecyclerScrollMoreListener : RecyclerView.OnScrollListener
    {
        private OnLoadMoreListener loadMoreListener;
        private int currentPage = 0;
        private int previousTotalItemCount = 0;
        private bool loading = false;

        private RecyclerView.LayoutManager mLayoutManager;

        public RecyclerScrollMoreListener(LinearLayoutManager manager, OnLoadMoreListener listener)
        {
            this.mLayoutManager = manager;
            this.loadMoreListener = listener;
        }

        private int GetLastVisibleItem(int[] lastVisibleItemPositions)
        {
            int maxSize = 0;
            for (int i = 0; i < lastVisibleItemPositions.Length; i++)
            {
                if (i == 0)
                {
                    maxSize = lastVisibleItemPositions[i];
                }
                else if (lastVisibleItemPositions[i] > maxSize)
                {
                    maxSize = lastVisibleItemPositions[i];
                }
            }
            return maxSize;
        }

        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            if (loadMoreListener != null)
            {
                int lastVisibleItemPosition = 0;
                int totalItemCount = mLayoutManager.ItemCount;

                if (mLayoutManager.GetType() == typeof(StaggeredGridLayoutManager))
                {
                    int[] lastVisibleItemPositions = ((StaggeredGridLayoutManager)mLayoutManager).FindLastVisibleItemPositions(null);
                    lastVisibleItemPosition = GetLastVisibleItem(lastVisibleItemPositions);
                }
                else if (mLayoutManager.GetType() == typeof(LinearLayoutManager))
                {
                    lastVisibleItemPosition = ((LinearLayoutManager)mLayoutManager).FindLastVisibleItemPosition();
                }
                else if (mLayoutManager.GetType() == typeof(GridLayoutManager))
                {
                    lastVisibleItemPosition = ((GridLayoutManager)mLayoutManager).FindLastVisibleItemPosition();
                }

                if (totalItemCount < previousTotalItemCount)
                {
                    this.currentPage = 0;
                    this.previousTotalItemCount = totalItemCount;
                    if (totalItemCount == 0)
                    {
                        this.loading = true;
                    }
                }

                if (loading && (totalItemCount > previousTotalItemCount))
                {
                    loading = false;
                    previousTotalItemCount = totalItemCount;
                }

                int visibleThreshold = 5;
                if (!loading && (lastVisibleItemPosition + visibleThreshold) > totalItemCount)
                {
                    currentPage++;
                    loadMoreListener.OnLoadMore(currentPage, totalItemCount);
                    loading = true;
                }
            }
        }

        public interface OnLoadMoreListener
        {
            void OnLoadMore(int page, int total);
        }
    }
}