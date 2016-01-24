using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DbTool.DbClasses
{
    public class DbConnectionPool<T>
    {
        public delegate void DbActionHandle(T conn);
        /// <summary>  
        /// 最少连接数  
        /// </summary>  
        private int _minConn = 5;
        /// <summary>  
        /// 最大连接数  
        /// </summary>  
        private int _maxConn = 20;
        /// <summary>  
        /// 使用Stack保存数据库连接  
        /// </summary>  
        private Stack _connStack= new Stack(5);
        /// <summary>
        /// 当前连接数
        /// </summary>
        private int _connCount = 0;
        /// <summary>
        /// 等待同步事件
        /// </summary>
        private AutoResetEvent _waitEvent = new AutoResetEvent(true);

        protected void InitPool()
        {
            for (int i = 0; i < _minConn; i++)
            {
                T obj = CreateConnection();
                _connStack.Push(obj);
                _connCount++;
            }
        }

        protected virtual T CreateConnection()
        { 
            return default(T);
        }

        protected void ExcuteUsePool(DbActionHandle action)
        {
            T conn = PopConnection();
            try
            {
                action(conn);
            }
            finally
            {
                PushConnection(conn);
            }
        }

        protected T PopConnection()
        {
            T conn = default(T);
            if (_connStack.Count > 0)
            {
                lock (_connStack)
                {
                    conn = (T)_connStack.Pop();
                }
            }
            else
            {
                if (_connCount < _maxConn)
                {
                    conn = CreateConnection();
                    _connCount++;
                }
                else
                {
                    if (_waitEvent.WaitOne())
                    {
                        conn = PopConnection();
                    }
                }
            }
            return conn; 
        }

        protected void PushConnection(T conn)
        {
            lock (_connStack)
            {
                _connStack.Push(conn);
            }
            _waitEvent.Set();
        }
    }
}
