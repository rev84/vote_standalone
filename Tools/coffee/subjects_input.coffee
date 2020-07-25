$().ready ->
  $('#submit').on 'click', submit
  
submit = ->
  $('#submit').prop 'disabled', true
  params = 
    Title: if $('#Title').val() is '' then null else $('#Title').val()
    Artist: if $('#Artist').val() is '' then null else $('#Artist').val()
    Comment: if $('#Comment').val() is '' then null else $('#Comment').val()
    Url: if $('#Url').val() is '' then null else $('#Url').val()

  Utl.request 'subjects/create', params, onSuccess, onFailure

onSuccess = (res)->
  window.alert('登録に成功しました。')
  location.reload()

onFailure = (res)->
  window.alert('登録に失敗しました。')
  $('#submit').prop 'disabled', false
